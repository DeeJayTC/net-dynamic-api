/* eslint-disable no-new-func */
import Vue from 'vue'

const CapitalizeFunction = 'if (!value) return \'\' if (allWords) {  return value.replace(/\bw/g, (l) => l.toUpperCase())} else {  return value.replace(/\bw/, (l) => l.toUpperCase())}'

Vue.filter('capitalize', (value, allWords) => {
  const func = new Function(value,allWords, CapitalizeFunction)

  return func
})

Vue.filter('cap2', (value, allWords) => {
  if (!value) return '' 
  
  if (allWords) {  return value.replace(/\b\w/g, (l) => l.toUpperCase())} else { 
    return value.replace(/\b\w/, (l) => l.toUpperCase())
  }
})