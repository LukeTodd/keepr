<template>
  <div class="vault-margin">

    {{userVaultData.name}}
    {{userVaultData.description}}




  </div>
</template>

<script>
  export default {
    name: 'UserVaults',
    props: ['userVaultData'],

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
  .vault-margin {
    margin-top: 200px;
  }
</style>