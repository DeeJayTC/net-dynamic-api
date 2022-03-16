<template>
  <div class="w-full">
    <div class="d-flex align-center py-3">
      <div>
        <div class="display-1">{{ $t('ecommerce.cart') }}</div>
        <v-breadcrumbs :items="breadcrumbs" class="pa-0 py-2"></v-breadcrumbs>
      </div>
    </div>

    <v-row>
      <v-col cols="12" md="8">

        <!-- cart list -->
        <div v-if="cart.length === 0">
          <v-divider></v-divider>
          <div class="text-h5 pa-5 text-center">Empty Cart</div>
          <v-divider></v-divider>
        </div>
        <div v-for="(item, index) in cart" :key="index" class="my-2">
          <v-divider v-if="index !== 0" class="my-3"></v-divider>
          <div class="d-flex align-center justify-center font-weight-bold">
            <div class="d-none d-md-block">
              <v-img
                height="60"
                width="60"
                contain
                class="rounded mr-4"
                :src="require(`@/assets/images/ecommerce/${item.image}`)"
              ></v-img>
            </div>
            <div class="font-weight-bold flex-grow-1">
              {{ item.title }}
            </div>
            <div class="d-none d-sm-block mx-1 mx-sm-4">
              <div class="text-overline">{{ $t('ecommerce.price') }}:</div>
              {{ item.price | formatCurrency }}
            </div>
            <div class="mx-1 mx-sm-4">
              <v-select
                v-model="item.quantity"
                :items="[1, 2, 3, 4, 5]"
                :label="$t('ecommerce.quantity')"
                outlined
                hide-details
                dense
                style="max-width: 80px;"
              ></v-select>
            </div>
            <div class="mx-1 mx-sm-4">
              <div class="text-overline">{{ $t('ecommerce.total') }}:</div>
              {{ (item.price * item.quantity) | formatCurrency }}
            </div>
            <v-btn icon @click="cart.splice(index, 1)">
              <v-icon>mdi-close</v-icon>
            </v-btn>
          </div>
        </div>

        <div class="d-flex my-6">
          <v-btn color="secondary">
            <v-icon left>mdi-arrow-left</v-icon>
            {{ $t('ecommerce.continue') }}
          </v-btn>
        </div>
      </v-col>

      <v-col cols="12" md="4">
        <v-card class="pa-2">
          <div class="text-h5 mb-6">{{ $t('ecommerce.summary') }}</div>
          <div class="d-flex">
            <div>{{ $t('ecommerce.subtotal') }}:</div>
            <v-spacer></v-spacer>
            <div>{{ subtotal | formatCurrency }}</div>
          </div>
          <v-divider class="my-2"></v-divider>
          <div v-if="discount" class="d-flex">
            <div>{{ $t('ecommerce.discount') }}:</div>
            <v-spacer></v-spacer>
            <div>- {{ discount | formatCurrency }}</div>
          </div>
          <v-divider class="my-2"></v-divider>
          <div class="d-flex text-h6">
            <div class="text-uppercase">{{ $t('ecommerce.total') }}:</div>
            <v-spacer></v-spacer>
            <div>{{ total | formatCurrency }}</div>
          </div>
          <v-btn
            large
            color="success"
            block
            class="mt-8"
            :disabled="cart.length === 0"
          >
            <v-icon left>mdi-cart-outline</v-icon>
            {{ $t('ecommerce.checkout') }}
          </v-btn>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import cart from './content/cart'

export default {
  data() {
    return {
      isLoading: false,
      breadcrumbs: [{
        text: 'Ecommerce',
        disabled: false,
        to: '/ecommerce/list'
      }, {
        text: 'Cart'
      }],

      discount: 10,

      cart
    }
  },
  computed: {
    subtotal() {
      let total = 0

      this.cart.forEach((c) => {
        total += c.quantity * c.price
      })

      return total
    },
    total() {
      const total = this.subtotal - this.discount

      return total < 0 ? 0 : total
    }
  }
}
</script>
