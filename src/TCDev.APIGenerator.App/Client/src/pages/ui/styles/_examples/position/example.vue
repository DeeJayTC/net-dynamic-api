<template>
  <v-card>
    <v-card-text>
      <div class="position-relative pa-2">Position Relative</div>
      <div class="position-md-fixed pa-2" style="left: 25%">Position Fixed (md and up)</div>
      <div class="position-relative pa-2 mt-5">
        <div class="position-absolute pa-2" style="right: 0">Position Absolute</div>
      </div>

      <div class="mt-10 pa-2 grey lighten-3" style="height: 200px; overflow-y: scroll;">
        <div class="position-sticky pa-2 grey lighten-2" style="top: 0;">Position Sticky</div>
        <p style="height: 400px">Scroll me sticky</p>
      </div>
      <div class="position-static pa-2">Position Static</div>
    </v-card-text>
  </v-card>
</template>
