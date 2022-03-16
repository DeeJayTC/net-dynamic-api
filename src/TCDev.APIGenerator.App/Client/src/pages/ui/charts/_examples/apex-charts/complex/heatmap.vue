<template>
  <div v-if="showChart">
    <apexchart type="heatmap" height="350" :options="chartOptions" :series="series"></apexchart>
  </div>
</template>

<script>
export default {
  data() {
    return {
      showChart: false,
      series: [],
      chartOptions: {
        chart: {
          height: 350,
          type: 'heatmap'
        },
        dataLabels: {
          enabled: false
        },
        colors: ['#008FFB'],
        title: {
          text: 'HeatMap Chart (Single color)'
        }
      }
    }
  },
  mounted() {
    this.series = [{
      name: 'Metric1',
      data: this.generateData(18, {
        min: 0,
        max: 90
      })
    },
    {
      name: 'Metric2',
      data: this.generateData(18, {
        min: 0,
        max: 90
      })
    },
    {
      name: 'Metric3',
      data: this.generateData(18, {
        min: 0,
        max: 90
      })
    },
    {
      name: 'Metric4',
      data: this.generateData(18, {
        min: 0,
        max: 90
      })
    },
    {
      name: 'Metric5',
      data: this.generateData(18, {
        min: 0,
        max: 90
      })
    },
    {
      name: 'Metric6',
      data: this.generateData(18, {
        min: 0,
        max: 90
      })
    },
    {
      name: 'Metric7',
      data: this.generateData(18, {
        min: 0,
        max: 90
      })
    },
    {
      name: 'Metric8',
      data: this.generateData(18, {
        min: 0,
        max: 90
      })
    },
    {
      name: 'Metric9',
      data: this.generateData(18, {
        min: 0,
        max: 90
      })
    }]

    this.showChart = true
  },
  methods: {
    generateData(count, yrange) {
      let i = 0

      const series = []

      while (i < count) {
        const x = (i + 1).toString()

        const y = Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min

        series.push({
          x: x,
          y: y
        })
        i++
      }

      return series
    }
  }
}
</script>
