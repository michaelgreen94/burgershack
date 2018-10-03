<template>
  <div class="burgers">
    <div class="burger" v-for="burger in burgers" :key="burger._id">
      <p>{{burger.name}}</p>
      <p>{{burger.description}}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "burger",
  computed: {
    burgers() {
      return this.$store.state.burgers;
    }
  }
};
</script>

<style scoped>
.burger {
  border: 1px solid black;
}
</style>
