<template>
  <div>
    <div class="card">
      <h5 class="card-title">{{UserKeepData.name}}</h5>
      <img v-bind:src="UserKeepData.img">
      <div class="card-body">
        <p class="card-text">{{UserKeepData.description}}
        </p>
        <button @click="deleteKeep(UserKeepData)" class="btn btn-primary">Delete Keep</button>
      </div>
    </div>





  </div>
</template>

<script>

  export default {
    name: 'UserKeeps',
    props: ['UserKeepData'],

    mounted() {

    },
    computed: {

    },
    methods: {
      deleteKeep(UserKeepData) {
        return this.$store.dispatch('deleteKeep', UserKeepData.id)
      }
    },
    components: {

    }
  }
</script>

<style>

</style>