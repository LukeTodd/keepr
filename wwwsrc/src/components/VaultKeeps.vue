<template>
  <div>
    <div class="card">
      <h5 class="card-title">{{VaultKeepData.name}}</h5>
      <img v-bind:src="VaultKeepData.img">
      <div class="card-body">
        <p class="card-text">{{VaultKeepData.description}}
        </p>
        <button @click="deleteKeep()" class="btn btn-primary">Delete From Vault</button>

      </div>
    </div>
  </div>
</template>


<script>
  import VaultKeeps from '@/components/VaultKeeps.vue'
  export default {
    name: "VaultKeeps",
    props: ['VaultKeepData'],

    mounted() {
      return this.$store.dispatch('getVaultKeeps', this.$route.params.id)
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      deleteKeep() {
        let keepId = this.VaultKeepData.id
        let vaultId = +this.$route.params.id
        let payload = {
          keepId,
          vaultId
        }
        return this.$store.dispatch('deleteVaultKeeps', payload)
      }
    },
    components: {
      VaultKeeps
    }
  }

</script>


<style>

</style>