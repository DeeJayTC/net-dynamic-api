<template>
  <div v-if="showChart">
    <apexchart type="bubble" height="350" :options="chartOptions" :series="series"></apexchart>
  </div>
</template>

<script>
function generateData(baseval, count, yrange) {
  let i = 0

  const series = []

  while (i < count) {
    const x = Math.floor(Math.random() * (750 - 1 + 1)) + 1
    const y = Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min

    const z = Math.floor(Math.random() * (75 - 15 + 1)) + 15

    series.push([x, y, z])
    baseval += 86400000
    i++
  }

  return series
}

export default {
  data() {
    return {
      showChart: false,
      series: [{
        name: 'Bubble1',
        data: generateData(new Date('11 Feb 2017 GMT').getTime(), 20, {
          min: 10,
          max: 60
        })
      },
      {
        name: 'Bubble2',
        data: generateData(new Date('11 Feb 2017 GMT').getTime(), 20, {
          min: 10,
          max: 60
        })
      },
      {
        name: 'Bubble3',
        data: generateData(new Date('11 Feb 2017 GMT').getTime(), 20, {
          min: 10,
          max: 60
        })
      },
      {
        name: 'Bubble4',
        data: generateData(new Date('11 Feb 2017 GMT').getTime(), 20, {
          min: 10,
          max: 60
        })
      }],
      chartOptions: {
        chart: {
          height: 350,
          type: 'bubble'
        },
        dataLabels: {
          enabled: false
        },
        fill: {
          opacity: 0.8
        },
        title: {
          text: 'Simple Bubble Chart'
        },
        xaxis: {
          tickAmount: 12,
          type: 'category'
        },
        yaxis: {
          max: 70
        }
      }
    }
  },
  mounted() {
    this.showChart = true
  }
}
</script>
