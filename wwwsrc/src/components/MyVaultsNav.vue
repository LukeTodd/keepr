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
          <li class="nav-item active">
            <a class="nav-link" @click="$router.push({name: 'home'})" href="#">All Keeps<span
                class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a class="nav-link" @click="$router.push({ name: 'myKeeps'})" href="#">My Keeps</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" data-toggle="modal" data-target="#exampleModal" href="#">Create Vault</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" @click="logout" href="#">Logout</a>
          </li>
        </ul>
        <form class="form-inline my-2 my-lg-0">
          <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
          <button class="btn bg-blue my-2 my-sm-0" type="submit">Search</button>
        </form>
      </div>
    </nav>
    <!-- modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Create A Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form class="row" @submit.prevent="createVault()">
              <div class="col-12">
                <input class="formfield" type="text" v-model="newVault.name" name="Name" placeholder="Title:" required>
                <br>
                <input class="formfield" type="text" v-model="newVault.description" name="Description"
                  placeholder="Description:">
              </div>
              <div class="modal-footer">
                <button type="submit" class="btn btn-secondary">Submit</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

  export default {
    name: "myKeepsNav",
    mounted() {

    },
    data() {
      return {
        newVault: {
          name: "",
          description: "",
          userId: ""
        }
      }
    },
    computed: {

    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      },
      createVault() {
        let name = this.newVault.name
        let description = this.newVault.description
        let userId = this.$store.state.user.id
        let payload = {
          name,
          description,
          userId
        }
        this.$store.dispatch('createVault', payload)
      }
    },
    components: {

    }
  }
</script>

<style>
</style>