<template>
  <div>
    {{UserKeepData.name}}
    <img v-bind:src="UserKeepData.img">
    {{UserKeepData.description}}


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

    },
    components: {

    }
  }
</script>

<style>

</style>