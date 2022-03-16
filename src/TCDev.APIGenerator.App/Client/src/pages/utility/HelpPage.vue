<template>
  <div class="py-3 min-w-0 w-full">
    <div class="display-1">{{ $t('common.faq') }}</div>
    <v-breadcrumbs :items="breadcrumbs" class="pa-0 py-2"></v-breadcrumbs>

    <!-- search card -->
    <v-card img="/images/demo/cards/material2.jpg" class="mb-5">
      <div class="pa-4 py-8">
        <v-text-field
          v-model="search"
          solo
          hide-details
          append-icon="mdi-magnify"
          placeholder="Search"
        ></v-text-field>
      </div>
    </v-card>

    <!-- faqs -->
    <v-row>
      <v-col cols="12" md="3" xl="2">
        <div class="sticky" style="top: 90px">
          <div class="title mb-2">Contents</div>
          <div v-for="faq in faqs" :key="faq.id" class="mb-1">
            <v-btn text color="primary" @click="$vuetify.goTo(`#${faq.id}`, { offset: 30 })">{{ faq.title }}</v-btn>
          </div>
        </div>
      </v-col>

      <v-col cols="12" md="9" xl="10">
        <div v-for="faq in faqs" :id="faq.id" :key="faq.id">
          <div id="#general" class="title pb-2">{{ faq.title }}</div>
          <v-expansion-panels class="mb-4" multiple>
            <v-expansion-panel
              v-for="(item,i) in faq.items"
              :key="i"
            >
              <v-expansion-panel-header class="font-weight-black">{{ item.title }}</v-expansion-panel-header>
              <v-expansion-panel-content>
                {{ item.content }}
              </v-expansion-panel-content>
            </v-expansion-panel>
          </v-expansion-panels>
        </div>
      </v-col>
    </v-row>

    <div class="caption mt-2 text-center">
      {{ $t('faq.call') }}
      <router-link to="">{{ $t('common.contact') }}</router-link>
    </div>
  </div>
</template>

<script>
/*
|---------------------------------------------------------------------
| Help Page Component
|---------------------------------------------------------------------
|
| Template to show frequently asked questions to your users
|
*/
export default {
  data() {
    return {
      search: '',

      breadcrumbs: [{
        text: 'Pages',
        disabled: false,
        href: '#'
      }, {
        text: 'FAQ'
      }],

      faqs: [{
        id: 'general',
        title: 'General Resources',
        items: [{
          title: 'Can I use a purchased item in a freelance project or contract work for a client?',
          content: 'Yes. However, if the client intends to charge End Users in any way from the End Product you create, you will need to purchase an Extended License. If you create the End Product for a client, your rights to purchased Items are transferred from you to your client.'
        }, {
          title: 'What is an End Product?',
          content: 'An End Product is work that is designed or developed for a single, paid client. This website can not be resold as a product to multiple users. For more information on selling products to multiple users.'
        }, {
          title: 'What are the End Product requirements?',
          content: 'An End Product must be a unique implementation of the Item, often requiring limited copy and content changes. For example, if you purchase a resume template, you may use the Item for yourself or a client after having input personal information (you may not resell it as stock).'
        }, {
          title: 'What is Personal Use, Commerical Work, Contracted Work, Client Work, etc.?',
          content: 'If the created site can not charge users in any way, it is considered for Personal Use and a Regular License can be used. For End Products that can charge users, such as a Software as a Service application, or an e-commerce site, you should use an Extended License. For any End Products that will be sold in its entirety, such as creating software that is distributed digitally, use an Unlimited License.'
        }, {
          title: 'What is Personal Use?',
          content: 'A Personal Use License can only be used for 1 End Product that does not charge users in any way.'
        }, {
          title: 'What is Commerical Use?',
          content: 'A Commercial Use License can only be used for 1 End Product that charges or will charge users.'
        }, {
          title: 'What is Unlimited Use?',
          content: 'An Extended Use License can be used for any number of Personal and Commercial projects.'
        }]
      }, {
        id: 'licenses',
        title: 'Licenses',
        items: [{
          title: 'Personal Use',
          content: 'Digital products purchased under the Standard License may be used one time in an End Product for Personal Use (an End Product that does not charge End Users).'
        }, {
          title: 'Commercial Use',
          content: 'Digital products purchased under the Extended License may be used an unlimited amount of times for Personal Use, and one time to create a single End Product that does charge End Users.'
        }, {
          title: 'Unlimited Use',
          content: 'An Unlimited License can be used an unlimited amount of times for Personal Use, Commercial Use, and Commercial End Products.'
        }]
      }]
    }
  }
}
</script>
