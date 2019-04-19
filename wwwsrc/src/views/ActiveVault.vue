<template>
  <div class="row">
    <div class="col-12">
      <div class="row">
        <div class="col-12">
          <vault-keep-nav></vault-keep-nav>
        </div>
      </div>
      <div class="row">
        <div class="col-6 vk-margin">
          <h3></h3>
          <vault-keeps v-for="vaultKeep in vaultKeeps" :VaultKeepData="vaultKeep"></vault-keeps>
        </div>
      </div>
    </div>
  </div>


</template>

<script>
  import VaultKeepNav from "@/components/VaultKeepNav.vue"
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
      VaultKeeps,
      VaultKeepNav
    }
  }


</script>


<style>
  .vk-margin {
    margin-top: 150px;
  }
</style>