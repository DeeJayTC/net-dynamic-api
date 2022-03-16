<template>
  <v-card class="pa-2">
    <h1>Please verify the email</h1>
    <div class="mb-6 overline">Please check your email for the link to verify the email.</div>

    <v-btn
      :loading="isLoading"
      :disabled="disabled"
      block
      depressed
      x-large
      color="primary"
      @click="resend"
    >Re-send email {{ seconds }}</v-btn>
  </v-card>
</template>

<script>
/*
|---------------------------------------------------------------------
| Verify Email Page Component
|---------------------------------------------------------------------
|
| Template to wait for the verification on the user email
|
*/

const TIMEOUT = 10

export default {
  data() {
    return {
      isLoading: false,
      disabled: true,
      times: 0,
      resendInterval: null,
      secondsToEnable: TIMEOUT,
      seconds: ''
    }
  },
  mounted() {
    this.setTimer()
  },
  beforeDestroy() {
    clearInterval(this.resendInterval)
  },
  methods: {
    async resend() {
      this.setTimer()
    },
    setTimer() {
      this.disabled = true
      this.times++
      this.secondsToEnable = TIMEOUT * this.times

      this.resendInterval = setInterval(() => {
        if (this.secondsToEnable === 0) {
          clearInterval(this.resendInterval)
          this.seconds = ''
          this.disabled = false
        } else {
          this.seconds = `( ${this.secondsToEnable} )`
          this.secondsToEnable--
        }
      }, 1000)
    }
  }
}
</script>
