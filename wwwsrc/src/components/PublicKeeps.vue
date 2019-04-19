<template>
  <div class=" d-flex pkmargin">
    <div class="card">
      <h5 class="card-title">{{keepData.name}}</h5>
      <img v-bind:src="keepData.img">
      <div class="card-body">
        <p class="card-text">{{keepData.description}}
        </p>
      </div>
    </div>
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
  .pkmargin {
    margin-top: 150px;
  }
</style>