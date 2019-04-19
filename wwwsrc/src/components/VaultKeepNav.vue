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
            <a class="nav-link" @click="$router.push({name: 'myVaults'})" href="#">My Vaults</a>
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

  </div>
</template>

<script>

  export default {
    name: "myKeepsNav",
    mounted() {

    },
    data() {
      return {

      }
    },
    computed: {

    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      }
    },
    components: {

    }
  }
</script>

<style>
</style>