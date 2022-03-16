<template>
  <div class="text-h5">{{ 1239898.123 | formatCurrency({
    label: 'USD',
    decimalDigits: 2,
    decimalSeparator: '.',
    thousandsSeparator: ',',
    currencySymbol: '$',
    currencySymbolNumberOfSpaces: 0,
    currencySymbolPosition: 'left'
  }) }}</div>
</template>
