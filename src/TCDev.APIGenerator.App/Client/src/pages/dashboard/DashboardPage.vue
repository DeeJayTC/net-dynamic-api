<template>
  <div class="d-flex flex-grow-1 flex-column">
    <v-row class="flex-grow-0" dense>
      <v-col cols="12" xl="4">
        <sales-card
          class="h-full"
          style="min-height: 380px"
          :value="1837.32"
          :percentage="3.2"
          :loading="isLoading1"
          :percentage-label="$t('dashboard.lastweek')"
          :action-label="$t('dashboard.viewReport')"
        ></sales-card>
      </v-col>

      <v-col cols="12" md="6" xl="4">
        <activity-card class="h-full" />
      </v-col>

      <v-col cols="12" md="6" xl="4">
        <sources-card
          :label="$t('dashboard.sources')"
          class="h-full"
          style="min-height: 380px"
          color="#8c9eff"
          :value="432"
          :percentage="4.3"
          :loading="isLoading2"
          :percentage-label="$t('dashboard.lastweek')"
          :series="[44, 55, 41, 17]"
        ></sources-card>
      </v-col>
    </v-row>

    <v-row class="flex-grow-0" dense>
      <v-col cols="12" lg="6">
        <table-card class="h-full" :label="$t('dashboard.recentOrders')" />
      </v-col>
      <v-col cols="12" lg="6">
        <div class="d-flex flex-column flex-grow-1 h-full">
          <track-card
            :label="$t('dashboard.orders')"
            class="h-full"
            color="#8c9eff"
            :value="432"
            :percentage="4.3"
            :percentage-label="$t('dashboard.lastweek')"
            :loading="isLoading3"
            :series="ordersSeries"
          ></track-card>
          <track-card
            :label="$t('dashboard.customers')"
            class="h-full mt-2"
            :color="theme.success"
            :value="178"
            :percentage="2.12"
            :percentage-label="$t('dashboard.lastweek')"
            :loading="isLoading3"
            :series="customersSeries"
          ></track-card>
        </div>
      </v-col>
    </v-row>

    <v-row class="flex-grow-0" dense>
      <v-col cols="12" xl="6">
        <todo-card style="min-height: 380px"/>
      </v-col>
      <v-col cols="12" xl="6">
        <tickets-card
          :label="$t('dashboard.tickets')"
          class="h-full"
          color="#8c9eff"
          :value="32"
          :percentage="-8.3"
          :percentage-label="$t('dashboard.lastweek')"
          :loading="isLoading4"
          :series="ordersSeries"
        ></tickets-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
// DEMO Cards for dashboard
import ActivityCard from '../../components/dashboard/ActivityCard'
import SalesCard from '../../components/dashboard/SalesCard'
import TrackCard from '../../components/dashboard/TrackCard'
import TableCard from '../../components/dashboard/TableCard'
import SourcesCard from '../../components/dashboard/SourcesCard'
import TicketsCard from '../../components/dashboard/TicketsCard'
import TodoCard from '../../components/dashboard/TodoCard'

export default {
  components: {
    SalesCard,
    ActivityCard,
    TrackCard,
    TableCard,
    SourcesCard,
    TicketsCard,
    TodoCard
  },
  data() {
    return {
      loadingInterval: null,

      isLoading1: true,
      isLoading2: true,
      isLoading3: true,
      isLoading4: true,

      ordersSeries: [{
        name: 'Orders',
        data: [
          ['2020-02-02', 34],
          ['2020-02-03', 43],
          ['2020-02-04', 40],
          ['2020-02-05', 43]
        ]
      }],

      customersSeries: [{
        name: 'Customers',
        data: [
          ['2020-02-02', 13],
          ['2020-02-03', 11],
          ['2020-02-04', 13],
          ['2020-02-05', 12]
        ]
      }]
    }
  },
  computed: {
    theme() {
      return this.$vuetify.theme.isDark
        ? this.$vuetify.theme.defaults.dark
        : this.$vuetify.theme.defaults.light
    }
  },
  mounted() {
    let count = 0

    // DEMO delay for loading graphics
    this.loadingInterval = setInterval(() => {
      this[`isLoading${count++}`] = false
      if (count === 4) this.clear()
    }, 400)
  },
  beforeDestroy() {
    this.clear()
  },
  methods: {
    clear() {
      clearInterval(this.loadingInterval)
    }
  }
}
</script>
