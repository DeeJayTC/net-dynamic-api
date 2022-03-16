<template>
  <e-charts
    ref="radar"
    style="width: 100%"
    autoresize
    :options="radar"
    auto-resize
  />
</template>

<script>
export default {
  data() {
    return {
      radar:{
        tooltip: {},
        radar: {
          indicator: [
            { name: 'Attack', max: 20 },
            { name: 'Defensive', max: 20 },
            { name: 'Speed', max: 20 },
            { name: 'Power', max: 20 },
            { name: 'Endurance', max: 20 },
            { name: 'Agile', max: 20 }
          ]
        },
        series: [{
          name: 'Ability value',
          type: 'radar',
          data: [{ value: [19,9,18,16,16,20] }]
        }]
      }
    }
  }
}
</script>
