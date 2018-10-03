<template>
  <div class="home">
    <burger/>
  </div>
</template>

<script>
// @ is an alias to /src
import Burger from "@/components/Burger.vue";

export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getAllBurgers");
  },
  // methods: {
  //   stockBurgers() {
  //     this.$store.dispatch("getAllBurgers");
  //   }
  // },
  components: {
    Burger
  }
};
</script>
