<template>
  <div class="d-flex flex-column flex-grow-1">
    <div class="d-flex flex-column flex-md-row align-md-end py-3">
      <div>
        <div class="display-1">{{ $t('ecommerce.products') }}</div>
        <v-breadcrumbs :items="breadcrumbs" class="pa-0 py-2"></v-breadcrumbs>
      </div>
      <v-spacer></v-spacer>
      <v-text-field
        v-model="searchQuery"
        append-icon="mdi-magnify"
        solo
        rounded
        hide-details
        dense
        clearable
        :placeholder="$t('ecommerce.search')"
        @keyup.enter="searchProduct(searchQuery)"
      ></v-text-field>
    </div>

    <div class="d-flex">

      <!-- product filters -->
      <v-responsive width="240" class="overflow-visible mr-5 d-none d-sm-block flex-grow-0">
        <div class="text-h6 mb-3">{{ $t('ecommerce.filters') }}</div>
        <div>
          <div class="font-weight-bold mb-1">{{ $t('ecommerce.collections') }}</div>
          <div>
            <router-link to="#" class="text-decoration-none">Shoes</router-link>
          </div>
          <div class="font-weight-bold">
            <router-link to="#" class="text-decoration-none">T-Shirts</router-link>
          </div>
          <div>
            <router-link to="#" class="text-decoration-none">Hoodies</router-link>
          </div>

          <div class="font-weight-bold mt-3">{{ $t('ecommerce.priceRange') }}</div>
          <v-range-slider
            v-model="priceFilter"
            :max="1000"
            step="10"
            thumb-label
            hide-details
            ticks
            tick-size="4"
          ></v-range-slider>

          <div class="font-weight-bold mt-3">{{ $t('ecommerce.customerReviews') }}</div>
          <v-radio-group v-model="reviewFilter" dense hide-details>
            <v-radio
              v-for="n in 5"
              :key="n"
              :value="n"
              class="ma-0"
            >
              <template #label>
                <v-rating
                  :value="5 - n"
                  background-color="orange lighten-3"
                  color="orange"
                  dense
                  small
                  readonly
                ></v-rating>
                <span class="font-weight-bold ml-1">{{ $t('ecommerce.up') }}</span>
              </template>
            </v-radio>
          </v-radio-group>

          <div class="font-weight-bold mt-3">{{ $t('ecommerce.brand') }}</div>
          <v-checkbox
            v-model="brandFilter"
            hide-details
            class="ma-0"
            dense
            label="Ardidas"
            value="Ardidas"
          ></v-checkbox>
          <v-checkbox
            v-model="brandFilter"
            hide-details
            class="ma-0"
            dense
            label="Niko"
            value="Niko"
          ></v-checkbox>
          <v-checkbox
            v-model="brandFilter"
            hide-details
            class="ma-0"
            dense
            label="Pumo"
            value="Pumo"
          ></v-checkbox>
          <v-checkbox
            v-model="brandFilter"
            hide-details
            class="ma-0"
            dense
            label="Old Balance"
            value="Old Balance"
          ></v-checkbox>
          <v-checkbox
            v-model="brandFilter"
            hide-details
            class="ma-0"
            dense
            label="Vins"
            value="Vins"
          ></v-checkbox>
        </div>
      </v-responsive>

      <!-- product list -->
      <div class="flex-grow-1 min-w-0">
        <div class="text-h6 mb-1">{{ $t('ecommerce.results', [8, 2092]) }}</div>
        <v-row>
          <v-col
            v-for="(product, i) in products"
            :key="i"
            cols="12"
            md="6"
            lg="4"
            xl="3"
          >
            <v-card class="text-center pa-1" :to="`/ecommerce/product-details?productId=${i}`">
              <v-img :src="require(`@/assets/images/ecommerce/${product.image}`)" height="460" contain></v-img>
              <div class="pa-3">
                <div class="text-h6">{{ product.title }}</div>
                <div>
                  <v-rating
                    :value="product.rating"
                    dense
                    background-color="orange lighten-3"
                    color="orange"
                    small
                    readonly
                  ></v-rating>
                </div>
                <div class="mt-2">
                  <span class="text-decoration-line-through mr-1">{{ product.priceCompare | formatCurrency }}</span>
                  <span class="font-weight-bold text-h6">{{ product.price | formatCurrency }}</span>
                </div>
              </div>
            </v-card>
          </v-col>
        </v-row>
        <v-pagination
          v-model="page"
          class="my-4"
          :length="4"
          circle
        ></v-pagination>
      </div>
    </div>
  </div>
</template>

<script>
import products from './content/products'

export default {
  components: {
  },
  data() {
    return {
      isLoading: false,
      breadcrumbs: [{
        text: 'Products',
        disabled: false,
        to: '#'
      }, {
        text: 'List'
      }],

      page: 2,
      searchQuery: '',

      // filters
      priceFilter: [100, 500],
      reviewFilter: 2,
      brandFilter: ['Ardidas', 'Old Balance'],

      products
    }
  },
  methods: {
    searchProduct() {}
  }
}
</script>
