<template>
  <div>
    {{keepData.name}}
    <img v-bind:src="keepData.img">
    {{keepData.description}}

  </div>
</template>

<script>

  export default {
    name: 'PublicKeeps',
    props: ['keepData'],

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