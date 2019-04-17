<template>
  <div class="row">
    <div class="col-12">
      <my-vaults-nav></my-vaults-nav>
    </div>
    <div class="col-12">
      <user-vaults v-for="userVault in userVaults" :userVaultData="userVault"></user-vaults>
    </div>
  </div>
</template>

<script>
  import UserVaults from '@/components/UserVaults.vue'
  import MyVaultsNav from '@/components/MyVaultsNav.vue'
  export default {
    name: "myVaults",
    mounted() {
      return this.$store.dispatch('getVaultsByUser')
    },
    computed: {
      userVaults() {
        return this.$store.state.vaults
      }
    },
    methods: {

    },
    components: {
      MyVaultsNav,
      UserVaults
    }
  }
</script>

<style>
</style>