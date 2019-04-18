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
            <drop-down v-for="vault in vaults" :vaultData='vault'></drop-down>
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
      }
    },
    components: {
      DropDown
    }
  }
</script>

<style>

</style>