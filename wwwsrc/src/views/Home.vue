<template>
  <div class="home row">
    <div class="col-12">
      <home-nav></home-nav>
    </div>
    <div class="col-12">
      <public-keeps v-for="keep in keeps" :keepData="keep"></public-keeps>
    </div>
  </div>
</template>

<script>
  import HomeNav from '@/components/HomeNav.vue'
  import PublicKeeps from '@/components/PublicKeeps.vue'
  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      this.$store.dispatch("getAllKeeps")
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      }
    },
    components: {
      PublicKeeps,
      HomeNav
    }
  };
</script>