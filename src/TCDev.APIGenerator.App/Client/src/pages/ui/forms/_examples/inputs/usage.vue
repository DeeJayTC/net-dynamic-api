<template>
  <v-container
    id="input-usage"
    fluid
  >
    <v-row>
      <v-col cols="12">
        <v-input
          :messages="['Messages']"
          append-icon="close"
          prepend-icon="phone"
        >
          Default Slot
        </v-input>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data () {
    return {
      text: ''
    }
  },
  methods: {
    appendIconCallback () {},
    prependIconCallback () {}
  }
}
</script>
