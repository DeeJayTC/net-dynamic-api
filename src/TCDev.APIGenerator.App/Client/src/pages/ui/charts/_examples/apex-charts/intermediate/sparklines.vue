<template>
  <div v-if="showChart">
    <div>
      <div class="row">
        <div class="col-md-4">
          <div id="chart-spark1">
            <apexchart type="area" height="160" :options="chartOptions" :series="series"></apexchart>
          </div>
        </div>
        <div class="col-md-4">
          <div id="chart-spark2">
            <apexchart type="area" height="160" :options="chartOptionsSpark2" :series="seriesSpark2"></apexchart>
          </div>
        </div>
        <div class="col-md-4">
          <div id="chart-spark3">
            <apexchart type="area" height="160" :options="chartOptionsSpark3" :series="seriesSpark3"></apexchart>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
const randomizeArray = function (arg) {
  const array = arg.slice()

  let currentIndex = array.length,
    temporaryValue, randomIndex

  while (0 !== currentIndex) {

    randomIndex = Math.floor(Math.random() * currentIndex)
    currentIndex -= 1

    temporaryValue = array[currentIndex]
    array[currentIndex] = array[randomIndex]
    array[randomIndex] = temporaryValue
  }

  return array
}

// data for the sparklines that appear below header area
const sparklineData = [47, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53, 61, 27, 54, 43, 19, 46]

export default {
  data() {
    return {
      showChart: false,
      series: [{
        data: randomizeArray(sparklineData)
      }],
      chartOptions: {
        chart: {
          type: 'area',
          height: 160,
          sparkline: {
            enabled: true
          }
        },
        stroke: {
          curve: 'straight'
        },
        fill: {
          opacity: 0.3
        },
        yaxis: {
          min: 0
        },
        colors: ['#DCE6EC'],
        title: {
          text: '$424,652',
          offsetX: 0,
          style: {
            fontSize: '24px'
          }
        },
        subtitle: {
          text: 'Sales',
          offsetX: 0,
          style: {
            fontSize: '14px'
          }
        }
      },

      seriesSpark2: [{
        data: randomizeArray(sparklineData)
      }],
      chartOptionsSpark2: {
        chart: {
          type: 'area',
          height: 160,
          sparkline: {
            enabled: true
          }
        },
        stroke: {
          curve: 'straight'
        },
        fill: {
          opacity: 0.3
        },
        yaxis: {
          min: 0
        },
        colors: ['#DCE6EC'],
        title: {
          text: '$235,312',
          offsetX: 0,
          style: {
            fontSize: '24px'
          }
        },
        subtitle: {
          text: 'Expenses',
          offsetX: 0,
          style: {
            fontSize: '14px'
          }
        }
      },

      seriesSpark3: [{
        data: randomizeArray(sparklineData)
      }],
      chartOptionsSpark3: {
        chart: {
          type: 'area',
          height: 160,
          sparkline: {
            enabled: true
          }
        },
        stroke: {
          curve: 'straight'
        },
        fill: {
          opacity: 0.3
        },
        xaxis: {
          crosshairs: {
            width: 1
          }
        },
        yaxis: {
          min: 0
        },
        title: {
          text: '$135,965',
          offsetX: 0,
          style: {
            fontSize: '24px'
          }
        },
        subtitle: {
          text: 'Profits',
          offsetX: 0,
          style: {
            fontSize: '14px'
          }
        }
      }
    }
  },
  mounted() {
    this.showChart = true
  }
}
</script>
