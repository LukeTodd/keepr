<template>
  <div class=" xs-col-12 col-12 no-padding">
    <nav class="navbar navbar-expand-lg bg-nav navbar fixed-top">
      <a class="navbar-brand blue" href="#">!Pintrest</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
          <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
            Login
          </button>



        </ul>
        <form class="form-inline my-2 my-lg-0">
          <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
          <button class="btn bg-blue my-2 my-sm-0" type="submit">Search</button>
        </form>
      </div>
    </nav>

    <!-- modal here -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Login</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form v-if="loginForm" @submit.prevent="loginUser">
              <input type="email" v-model="creds.email" placeholder="email">
              <input type="password" v-model="creds.password" placeholder="password">
              <button type="submit">Login</button>
            </form>
            <form v-else @submit.prevent="register">
              <input type="text" v-model="newUser.username" placeholder="name">
              <input type="email" v-model="newUser.email" placeholder="email">
              <input type="password" v-model="newUser.password" placeholder="password">
              <button type="submit">Create Account</button>
            </form>
            <div @click="loginForm = !loginForm">
              <p v-if="loginForm">No account Click to Register</p>
              <p v-else>Already have an account click to Login</p>
            </div>
          </div>
          <div class="modal-footer">


          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "login",
    mounted() {
      //checks for valid session
      this.$store.dispatch("authenticate");

    },
    data() {
      return {
        loginForm: true,
        creds: {
          email: "",
          password: ""
        },
        newUser: {
          email: "",
          password: "",
          username: ""
        }
      };
    },
    computed: {

    },
    methods: {
      register() {
        this.$store.dispatch("register", this.newUser);
      },
      loginUser() {
        this.$store.dispatch("login", this.creds);

      }
    }
  }
</script>



<style>
  .bg-nav {
    background-color: rgb(111, 38, 61);
  }

  .bg-blue {
    background-color: #007bff;
  }

  .blue {
    color: #007bff;
    text-shadow: black 1px 1px;

  }

  .no-padding {
    padding-left: 0px;
    padding-right: 0px;
  }
</style>