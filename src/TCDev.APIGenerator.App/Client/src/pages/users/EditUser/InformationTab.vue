<template>
  <v-card class="my-2">
    <v-card-title>User Information</v-card-title>
    <v-card-text>
      <v-form>
        <v-row>
          <v-col cols="12" md="6">
            <v-text-field value="First and two on el street" label="Address Line 1"></v-text-field>
            <v-text-field value="" label="Address Line 2"></v-text-field>
            <v-text-field value="1231" label="Zip Code"></v-text-field>
            <v-text-field value="Los Angeles" label="City"></v-text-field>
            <v-text-field value="California" label="State"></v-text-field>
            <v-text-field value="United States" label="Country"></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field value="+8484548112" label="Phone"></v-text-field>
            <v-menu
              ref="menu"
              v-model="menu"
              :close-on-content-click="false"
              transition="scale-transition"
              offset-y
              min-width="290px"
            >
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="date"
                  label="Birthday date"
                  readonly
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                ref="picker"
                v-model="date"
                :max="new Date().toISOString().substr(0, 10)"
                min="1950-01-01"
                @change="save"
              ></v-date-picker>
            </v-menu>
            <v-text-field value="https://" label="Website"></v-text-field>
            <v-radio-group v-model="gender" label="Gender">
              <v-radio label="Male" value="male"></v-radio>
              <v-radio label="Female" value="female"></v-radio>
              <v-radio label="Other" value="other"></v-radio>
            </v-radio-group>
          </v-col>
        </v-row>

        <div class="d-flex">
          <v-btn>Reset</v-btn>
          <v-spacer></v-spacer>
          <v-btn color="primary">Save</v-btn>
        </div>
      </v-form>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  data: () => ({
    date: '1990-10-09',
    menu: false,
    gender: 'male'
  }),
  watch: {
    menu (val) {
      val && setTimeout(() => (this.$refs.picker.activePicker = 'YEAR'))
    }
  },
  methods: {
    save (date) {
      this.$refs.menu.save(date)
    }
  }
}
</script>
