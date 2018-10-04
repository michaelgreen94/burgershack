<template>
  <div class="home">
    <v-form v-model="valid">
      <v-text-field v-model="name" :rules="nameRules" :counter="10" label="Name" required></v-text-field>
      <v-text-field v-model="description" :rules="descriptionRules" label="Description" required></v-text-field>
      <v-text-field v-model="price" :rules="priceRules" label="Price" required></v-text-field>
    </v-form>
    <burger />
  </div>
</template>

<script>
// @ is an alias to /src
import Burger from "@/components/Burger.vue";

export default {
  name: "home",
  data: {
    valid: false
  },
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