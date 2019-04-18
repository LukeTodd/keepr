<template>
  <a class="dropdown-item" href="#">{{vaultData.name}}</a>



</template>


<script>
  export default {
    name: 'DropDown',
    props: ['vaultData'],

    mounted() {

    }
  }
</script>