<template>
  <v-card class="min-w-0">
    <div class="email-app-top px-2 py-1 d-flex align-center">
      <v-btn icon @click="$router.go(-1)">
        <v-icon>mdi-arrow-left</v-icon>
      </v-btn>

      <div class="mx-3">
        <v-btn icon>
          <v-icon>bx-archive</v-icon>
        </v-btn>
        <v-btn icon>
          <v-icon>mdi-email-mark-as-unread</v-icon>
        </v-btn>
        <v-btn icon>
          <v-icon>bx-trash-alt</v-icon>
        </v-btn>
      </div>

      <v-spacer></v-spacer>

      <div class="caption mr-1">1 - 20 of 428</div>
      <v-btn icon disabled>
        <v-icon>mdi-chevron-left</v-icon>
      </v-btn>
      <v-btn icon>
        <v-icon>mdi-chevron-right</v-icon>
      </v-btn>
    </div>

    <v-divider></v-divider>

    <div class="d-flex pa-2">
      <div class="text-h6">Do you have Paris recommendations? Have you ever been?</div>

      <v-spacer></v-spacer>

      <div>
        <v-btn icon>
          <v-icon>mdi-printer</v-icon>
        </v-btn>
      </div>
    </div>

    <div class="pa-2">
      <v-expansion-panels v-model="emailsExpanded" multiple>
        <v-expansion-panel v-for="(item, index) in emails" :key="index">
          <v-expansion-panel-header>
            <template v-slot:default="{ open }">

              <div class="d-flex">
                <v-avatar size="36px">
                  <img :src="item.avatar" alt="">
                </v-avatar>

                <div class="mx-3 min-w-0">
                  <div class="font-weight-bold mb-1">{{ item.name }}</div>

                  <div v-show="open">
                    <v-menu offset-y right transition="slide-y-transition">
                      <template v-slot:activator="{ on }">
                        <v-btn text class="pa-0" v-on="on">
                          to me
                          <v-icon small right>mdi-chevron-down</v-icon>
                        </v-btn>
                      </template>
                      <v-card class="pa-2">
                        <div><span class="grey--text">from:</span> johnnilson@whatthisisnotarealemail.com</div>
                        <div><span class="grey--text">to:</span> clara@whatthisisnotarealemail.com</div>
                      </v-card>
                    </v-menu>
                  </div>
                  <div v-show="!open" class="text-truncate">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Non ut, soluta temporibus, culpa magnam harum quod asperiores excepturi iste veniam possimus dignissimos laboriosam ipsum voluptas repellat consequuntur vitae debitis consequatur.</div>
                </div>

                <v-spacer></v-spacer>

                <v-menu offset-y left transition="slide-y-transition">
                  <template v-slot:activator="{ on }">
                    <v-btn icon v-on="on">
                      <v-icon small>mdi-dots-vertical</v-icon>
                    </v-btn>
                  </template>
                  <v-list dense nav>
                    <v-list-item link>
                      <v-list-item-title>Forward</v-list-item-title>
                    </v-list-item>
                    <v-list-item link>
                      <v-list-item-title>Delete</v-list-item-title>
                    </v-list-item>
                  </v-list>
                </v-menu>
              </div>
            </template>
            <template v-slot:actions>
              <span></span>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content>
            <p>Hello,</p>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
            <p>Best regards</p>
          </v-expansion-panel-content>
        </v-expansion-panel>
      </v-expansion-panels>

      <v-card class="mt-4">
        <email-editor></email-editor>
      </v-card>
    </div>

  </v-card>
</template>

<script>
import EmailEditor from '../components/EmailEditor'

export default {
  components: {
    EmailEditor
  },
  data() {
    return {
      emailsExpanded: [3],
      emails: [{
        name: 'Ubaldo Romaguera',
        avatar: '/images/avatars/avatar1.svg'
      }, {
        name: 'Ruben Breitenberg',
        avatar: '/images/avatars/avatar2.svg'
      }, {
        name: 'Blaze Carter',
        avatar: '/images/avatars/avatar3.svg'
      }, {
        name: 'Bernita Lehner',
        avatar: '/images/avatars/avatar4.svg'
      }]
    }
  }
}
</script>

<style lang="scss" scoped>
.email-app-top {
  height: 82px;
}
</style>
