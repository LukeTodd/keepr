<template>
  <div class="row">
    <div class="col-12">
      <div class="row">
        <div class="col-12">
          <my-keeps-nav></my-keeps-nav>
        </div>
      </div>
      <div class="row">
        <div class="col-12">
          <h1 class="mykeepstitle"> MY KEEPS</h1>
        </div>
      </div>
      <div class="row">
        <div class="col-4 d-flex">
          <user-keeps v-for="userKeep in userKeeps" :UserKeepData="userKeep"></user-keeps>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import UserKeeps from '@/components/UserKeeps.vue'
  import MyKeepsNav from '@/components/MyKeepsNav.vue'
  export default {
    name: "myKeeps",
    mounted() {
      return this.$store.dispatch('getKeepsByUser')
    },

    computed: {
      userKeeps() {
        return this.$store.state.keeps
      }
    },
    methods: {

    },
    components: {
      MyKeepsNav,
      UserKeeps
    }
  }
</script>

<style>
  .mykeepstitle {
    margin-top: 150px;
  }
</style>