<template>
  <e-charts
    ref="bar"
    style="width: 100%"
    :options="polar"
    :theme="themeDark ? 'dark' : 'default'"
    auto-resize
  />
</template>

<script>
export default {
  data() {
    const data = []

    for (let i = 0; i <= 360; i++) {
      const t = i / 180 * Math.PI
      const r = Math.sin(2 * t) * Math.cos(2 * t)

      data.push([r, i])
    }

    return {
      themeDark: false,
      polar:{
        legend: {
          data: ['line']
        },
        polar: {
          center: ['50%', '54%']
        },
        tooltip: {
          trigger: 'axis',
          axisPointer: {
            type: 'cross'
          }
        },
        angleAxis: {
          type: 'value',
          startAngle: 0
        },
        radiusAxis: {
          min: 0
        },
        series: [
          {
            coordinateSystem: 'polar',
            name: 'line',
            type: 'line',
            showSymbol: false,
            data: data
          }
        ],
        animationDuration: 2000
      }
    }
  }
}
</script>
