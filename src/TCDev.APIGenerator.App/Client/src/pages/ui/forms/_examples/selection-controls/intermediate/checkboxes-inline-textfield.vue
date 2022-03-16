<template>
  <v-card>
    <v-card-text>
      <v-container>
        <v-row align="center">
          <v-checkbox
            v-model="includeFiles"
            hide-details
            class="shrink mr-2 mt-0"
          ></v-checkbox>
          <v-text-field label="Include files"></v-text-field>
        </v-row>
        <v-row align="center">
          <v-checkbox
            v-model="enabled"
            hide-details
          ></v-checkbox>
          <v-text-field
            :disabled="!enabled"
            label="I only work if you check the box"
          ></v-text-field>
        </v-row>
      </v-container>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  data: () => ({
    includeFiles: true,
    enabled: false
  })
}
</script>
