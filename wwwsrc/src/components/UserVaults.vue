<template>
  <div class="vault-margin">
    <div class="card">
      <div class="card-header">
        {{userVaultData.name}}
      </div>
      <div class="card-body">

        <p class="card-text">{{userVaultData.description}}</p>
        <button @click="deleteVault(userVaultData)" class="btn btn-primary">Delete Vault</button>
        <button @click="$router.push({name: 'activeVault', params: {id: userVaultData.id}})"
          class="btn btn-primary">View
          Vault</button>
      </div>
    </div>





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
      deleteVault(UserVaultData) {
        return this.$store.dispatch('deleteVault', UserVaultData.id)
      }
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