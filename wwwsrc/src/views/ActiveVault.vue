<template>
  <div class="row">
    <div class="col-12">
      <div class="row">
        <div class="col-12">

          <vault-keeps v-for="vaultKeep in vaultKeeps" :VaultKeepData="vaultKeep"></vault-keeps>
        </div>
      </div>
    </div>
  </div>


</template>

<script>
  import VaultKeeps from "@/components/VaultKeeps.vue"
  export default {
    name: "ActiveVault",
    props: [],

    mounted() {
      return this.$store.dispatch('getVaultKeeps', this.$route.params.id)
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {

    },
    components: {
      VaultKeeps
    }
  }


</script>


<style>
</style>