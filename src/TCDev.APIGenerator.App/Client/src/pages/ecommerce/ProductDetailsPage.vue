<template>
  <div class="w-full">
    <div class="d-flex py-3">
      <div>
        <div class="display-1">{{ product.title }}</div>
        <v-breadcrumbs :items="breadcrumbs" class="pa-0 py-2"></v-breadcrumbs>
      </div>
    </div>
    <v-card class="pa-3" flat>
      <v-row>
        <v-col cols="12" md="5">
          <div class="d-flex">
            <div v-if="product.image" class="mr-2">
              <v-card
                v-for="(image, i) in product.images"
                :key="i"
                @click="selectedImageIndex = i"
              >
                <v-img
                  height="80"
                  width="80"
                  class="rounded mb-2"
                  :src="require(`@/assets/images/ecommerce/${image}`)"
                ></v-img>
              </v-card>
            </div>
            <div class="d-flex align-center flex-grow-1 justify-center">
              <img
                v-if="product.image"
                :src="selectedImage"
                class="rounded"
                style="max-width: 100%; max-height: 460px"
              />
            </div>
          </div>
        </v-col>
        <v-col cols="12" md="4">
          <div class="d-flex"></div>
          <div class="font-weight-bold text-h5">{{ product.title }}</div>
          <div class="d-flex align-center">
            <v-rating
              :value="product.rating"
              background-color="orange lighten-3"
              color="orange"
              dense
              small
              readonly
            ></v-rating>
            <span class="text-overline ml-1">({{ product.reviews ? product.reviews.length : 0 }} {{ $t('ecommerce.customerReviews') }})</span>
          </div>
          <v-divider class="my-2"></v-divider>
          <div class="d-flex align-center text-h6">
            <div>{{ $t('ecommerce.price') }}:</div>
            <span class="text-decoration-line-through mx-1 font-weight-regular">{{ product.priceCompare | formatCurrency }}</span>
            <span>{{ product.price | formatCurrency }}</span>
          </div>
          <div class="mt-3 text-body-1">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Cupiditate totam consectetur consequatur. Repudiandae, voluptatem deserunt ex quia placeat est labore.
          </div>
          <v-divider class="my-2"></v-divider>
          <div class="font-weight-bold mb-1">{{ $t('ecommerce.about') }}</div>
          <ul>
            <li>Reinforced Seams</li>
            <li>Articulated Arms</li>
            <li>Durable</li>
            <li>Anti-odor</li>
            <li>Breathable Mesh</li>
          </ul>
        </v-col>
        <v-col cols="12" md="3">
          <v-card outlined class="pa-2">
            <div class="d-flex flex-column">
              <div class="text-body-1 font-weight-bold">{{ $t('ecommerce.shipping') }}</div>
              <div class="text-body-1">{{ $t('ecommerce.freeShipping') }}</div>

              <div class="text-h6 success--text my-3">{{ $t('ecommerce.inStock') }}</div>
              <v-select
                :items="[1, 2, 3, 4, 5]"
                :value="1"
                :label="$t('ecommerce.quantity')"
                outlined
                dense
              ></v-select>

              <v-btn color="primary" block large class="mb-2">{{ $t('ecommerce.addToCart') }}</v-btn>
              <v-btn color="secondary" block large>{{ $t('ecommerce.buyNow') }}</v-btn>
            </div>
          </v-card>
        </v-col>
      </v-row>
      <v-divider class="my-3"></v-divider>
      <div>
        <div class="text-h6">{{ $t('ecommerce.description') }}</div>
        <div class="text-body-1 my-2">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nostrum perferendis exercitationem rem sed fugiat, voluptatibus officia repudiandae itaque unde nesciunt sequi, ex repellendus tempore, veniam asperiores dolores facilis debitis similique nam optio cupiditate porro. Blanditiis cum expedita facere iusto dolore, praesentium vitae hic? Eaque suscipit fugit iusto, ab voluptatibus officia animi ipsam quae rem iste aliquid. Quo molestias possimus nisi accusamus ipsum error corrupti. Consequatur molestias itaque magnam libero asperiores similique nam quam in explicabo, aliquam ab laboriosam saepe modi blanditiis dolor esse laudantium at! Cumque odit illum possimus adipisci, quis praesentium fugiat id sit repudiandae eum. Eos, soluta ipsum.</div>
      </div>
      <v-divider class="my-3"></v-divider>
      <div>
        <div class="text-h6">{{ $t('ecommerce.reviews') }}</div>
        <div v-for="(item, k) in product.reviews" :key="k">
          <div class="font-weight-bold mt-2">{{ item.name }}</div>
          <div>
            <v-rating
              :value="item.rating"
              background-color="orange lighten-3"
              color="orange"
              dense
              small
              readonly
            ></v-rating>
          </div>
          <div>{{ item.review }}</div>
        </div>
      </div>
    </v-card>
  </div>
</template>

<script>
import products from './content/products'

export default {
  data() {
    return {
      isLoading: false,
      breadcrumbs: [{
        text: 'Products',
        disabled: false,
        to: '/ecommerce/list'
      }, {
        text: 'Product Details',
        disabled: true,
        href: '#'
      }],

      product: {},

      selectedImageIndex: 0
    }
  },
  computed: {
    selectedImage() {
      if (!this.product.images) return ''

      const image = this.product.images[this.selectedImageIndex]

      return require(`@/assets/images/ecommerce/${image}`)
    }
  },
  mounted() {
    if (typeof this.$route.query.productId !== 'undefined') {
      this.product = products[parseInt(this.$route.query.productId)]
    } else {
      this.product = products[0]
    }
  }
}
</script>
