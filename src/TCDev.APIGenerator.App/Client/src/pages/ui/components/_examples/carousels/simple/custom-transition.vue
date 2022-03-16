<template>
  <v-carousel>
    <v-carousel-item
      v-for="(item,i) in items"
      :key="i"
      :src="item.src"
      reverse-transition="fade-transition"
      transition="fade-transition"
    ></v-carousel-item>
  </v-carousel>
</template>

<script>
export default {
  data () {
    return {
      items: [
        {
          src: '/images/demo/carousel/squirrel.jpg'
        },
        {
          src: '/images/demo/carousel/sky.jpg'
        },
        {
          src: '/images/demo/carousel/bird.jpg'
        },
        {
          src: '/images/demo/carousel/planet.jpg'
        }
      ]
    }
  }
}
</script>
