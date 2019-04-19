<template>
  <div>
    <div class="card">
      <h5 class="card-title">{{UserKeepData.name}}</h5>
      <img v-bind:src="UserKeepData.img">
      <div class="card-body">
        <p class="card-text">{{UserKeepData.description}}
        </p>
        <button @click="deleteKeep(UserKeepData)" class="btn btn-primary">Delete Keep</button>
        <div class="dropdown">
          <a class="btn btn-secondary dropdown-toggle" href="#" role="button" id="dropdownMenuLink"
            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Add To Vault
          </a>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
            <!-- <drop-down v-for="vault in vaults" :vaultData='vault'></drop-down> -->
            <a class="dropdown-item" v-for="vault in vaults"
              @click="createVaultKeep(vault, UserKeepData)">{{vault.name}}</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import DropDown from "@/components/DropDown.vue"

  export default {
    name: 'UserKeeps',
    props: ['UserKeepData'],

    mounted() {

    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      deleteKeep(UserKeepData) {
        return this.$store.dispatch('deleteKeep', UserKeepData.id)
      },
      createVaultKeep(vault, UserKeepData) {
        let vaultId = vault.id
        let keepId = UserKeepData.id
        let userId = this.$store.state.user.id
        let payload = {
          vaultId,
          keepId,
          userId
        }
        this.$store.dispatch("createVaultKeep", payload)
      }
    },
    components: {
      DropDown
    }
  }
</script>

<style>

</style>