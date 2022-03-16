<template>
  <div class="d-flex flex-column flex-grow-1">
    <div class="d-flex align-center py-3">
      <div>
        <div class="display-1">{{ $t('ecommerce.orders') }}</div>
        <v-breadcrumbs :items="breadcrumbs" class="pa-0 py-2"></v-breadcrumbs>
      </div>
    </div>

    <v-card>
      <!-- orders list -->
      <v-row dense class="pa-2 align-center">
        <v-col cols="6">
          <v-menu offset-y left>
            <template v-slot:activator="{ on }">
              <transition name="slide-fade" mode="out-in">
                <v-btn v-show="selectedOrders.length > 0" v-on="on">
                  Actions
                  <v-icon right>mdi-menu-down</v-icon>
                </v-btn>
              </transition>
            </template>
            <v-list dense>
              <v-list-item @click>
                <v-list-item-title>Delete</v-list-item-title>
              </v-list-item>
            </v-list>
          </v-menu>

        </v-col>
        <v-col cols="6" class="d-flex text-right align-center">
          <v-text-field
            v-model="searchQuery"
            append-icon="mdi-magnify"
            class="flex-grow-1 mr-md-2"
            solo
            hide-details
            dense
            clearable
            placeholder="e.g. filter for id, email, name, etc"
            @keyup.enter="searchUser(searchQuery)"
          ></v-text-field>
          <v-btn
            :loading="isLoading"
            icon
            small
            class="ml-2"
            @click
          >
            <v-icon>mdi-refresh</v-icon>
          </v-btn>
        </v-col>
      </v-row>

      <v-data-table
        v-model="selectedOrders"
        show-select
        :headers="headers"
        :items="orders"
        :search="searchQuery"
        :items-per-page="18"
        class="flex-grow-1"
      >
        <template v-slot:item.id="{ item }">
          <div class="font-weight-bold"># <copy-label :text="item.id + ''" /></div>
        </template>

        <template v-slot:item.email="{ item }">
          <div class="d-flex align-center py-1">
            <v-avatar size="32" class="elevation-1 grey lighten-3">
              <v-img :src="item.avatar" />
            </v-avatar>
            <div class="ml-1 caption font-weight-bold">
              <copy-label :text="item.email" />
            </div>
          </div>
        </template>

        <template v-slot:item.total="{ item }">
          <div>{{ item.total | formatCurrency }}</div>
        </template>

        <template v-slot:item.status="{ item }">
          <v-chip
            label
            small
            class="font-weight-bold"
            :color="item.status === 'Paid' ? 'success' : 'warning'"
            :class="item.status === 'Paid' ? 'success--text text--darken-4' : 'warning--text text--darken-4'"
          >{{ item.status }}</v-chip>
        </template>

        <template v-slot:item.created="{ item }">
          <div>{{ item.created | formatDate('ll') }}</div>
        </template>

        <template v-slot:item.action="{ }">
          <div class="actions">
            <v-btn icon>
              <v-icon>mdi-open-in-new</v-icon>
            </v-btn>
          </div>
        </template>
      </v-data-table>
    </v-card>
  </div>
</template>

<script>
import orders from './content/orders'
import CopyLabel from '../../components/common/CopyLabel'

export default {
  components: {
    CopyLabel
  },
  data() {
    return {
      isLoading: false,
      breadcrumbs: [{
        text: 'Orders',
        disabled: false,
        href: '#'
      }, {
        text: 'List'
      }],

      searchQuery: '',
      selectedOrders: [],
      headers: [
        { text: 'Order Id', align: 'left', value: 'id' },
        { text: 'Email', value: 'email' },
        { text: 'Name', align: 'left', value: 'name' },
        { text: 'Date', value: 'created' },
        { text: 'Total', value: 'total' },
        { text: 'Payment Status', value: 'status' },
        { text: '', sortable: false, align: 'right', value: 'action' }
      ],

      orders
    }
  },
  watch: {
    selectedOrders(val) {

    }
  },
  methods: {
    searchUser() {},
    open() {}
  }
}
</script>

<style lang="scss" scoped>
.slide-fade-enter-active {
  transition: all 0.3s ease;
}
.slide-fade-leave-active {
  transition: all 0.3s cubic-bezier(1, 0.5, 0.8, 1);
}
.slide-fade-enter,
.slide-fade-leave-to {
  transform: translateX(10px);
  opacity: 0;
}
</style>
