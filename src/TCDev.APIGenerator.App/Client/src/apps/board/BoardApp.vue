<template>
  <div class="d-flex flex-grow-1 mt-2">
    <router-view :key="$route.fullPath"></router-view>
  </div>
</template>
