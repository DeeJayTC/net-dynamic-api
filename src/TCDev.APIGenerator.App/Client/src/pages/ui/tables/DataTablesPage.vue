<template>
  <ui-demo title="Data Tables" :snippets="snippets"><div class="mt-2">Please checkout the <a class="font-weight-bold" href="https://vuetifyjs.com/components/data-tables" target="_blank">Full Documentation</a></div></ui-demo>
</template>

<script>
import UiDemo from '@/components/demo/UIDemo'

// Snippets
import UsageSnippet from '!!raw-loader!./_examples/data-tables/usage.vue'
import SelectSnippet from '!!raw-loader!./_examples/data-tables/simple/select.vue'
import DenseSnippet from '!!raw-loader!./_examples/data-tables/simple/dense.vue'
import FilterableColumnsSnippet from '!!raw-loader!./_examples/data-tables/simple/filterable-columns.vue'
import FooterPropsSnippet from '!!raw-loader!./_examples/data-tables/simple/footer-props.vue'
import VirtualizedSnippet from '!!raw-loader!./_examples/data-tables/simple/virtualized.vue'
import HeaderlessSnippet from '!!raw-loader!./_examples/data-tables/simple/headerless.vue'
import LoadingSnippet from '!!raw-loader!./_examples/data-tables/simple/loading.vue'
import MultiSortSnippet from '!!raw-loader!./_examples/data-tables/simple/multi-sort.vue'
import SearchSnippet from '!!raw-loader!./_examples/data-tables/simple/search.vue'
import GroupSnippet from '!!raw-loader!./_examples/data-tables/simple/group.vue'
import SortSnippet from '!!raw-loader!./_examples/data-tables/intermediate/sort.vue'
import CustomFilterSnippet from '!!raw-loader!./_examples/data-tables/intermediate/custom-filter.vue'
import CustomizeFooterSnippet from '!!raw-loader!./_examples/data-tables/intermediate/customize-footer.vue'
import CustomizeHeaderSnippet from '!!raw-loader!./_examples/data-tables/intermediate/customize-header.vue'
import CustomizeRowsSnippet from '!!raw-loader!./_examples/data-tables/intermediate/customize-rows.vue'
import ExpandSnippet from '!!raw-loader!./_examples/data-tables/intermediate/expand.vue'
import PaginateSnippet from '!!raw-loader!./_examples/data-tables/intermediate/paginate.vue'
import ServerSnippet from '!!raw-loader!./_examples/data-tables/intermediate/server.vue'
import SimpleCheckboxSnippet from '!!raw-loader!./_examples/data-tables/intermediate/simple-checkbox.vue'
import SlotsSnippet from '!!raw-loader!./_examples/data-tables/intermediate/slots.vue'
import EditDialogSnippet from '!!raw-loader!./_examples/data-tables/complex/edit-dialog.vue'
import CrudSnippet from '!!raw-loader!./_examples/data-tables/complex/crud.vue'

export default {
  components: {
    UiDemo
  },
  data: () => ({
    snippets: [
      {
        title: 'Usage',
        snippet: UsageSnippet
      },
      {
        title: 'Select',
        snippet: SelectSnippet
      },
      {
        title: 'Dense',
        snippet: DenseSnippet
      },
      {
        title: 'Filterable Columns',
        snippet: FilterableColumnsSnippet
      },
      {
        title: 'Footer Props',
        snippet: FooterPropsSnippet
      },
      {
        title: 'Virtualized',
        snippet: VirtualizedSnippet
      },
      {
        title: 'Headerless',
        snippet: HeaderlessSnippet
      },
      {
        title: 'Loading',
        snippet: LoadingSnippet
      },
      {
        title: 'Multi Sort',
        snippet: MultiSortSnippet
      },
      {
        title: 'Search',
        snippet: SearchSnippet
      },
      {
        title: 'Group',
        snippet: GroupSnippet
      },
      {
        title: 'Sort',
        snippet: SortSnippet
      },
      {
        title: 'Custom Filter',
        snippet: CustomFilterSnippet
      },
      {
        title: 'Customize Footer',
        snippet: CustomizeFooterSnippet
      },
      {
        title: 'Customize Header',
        snippet: CustomizeHeaderSnippet
      },
      {
        title: 'Customize Rows',
        snippet: CustomizeRowsSnippet
      },
      {
        title: 'Expand',
        snippet: ExpandSnippet
      },
      {
        title: 'Paginate',
        snippet: PaginateSnippet
      },
      {
        title: 'Server',
        snippet: ServerSnippet
      },
      {
        title: 'Simple Checkbox',
        snippet: SimpleCheckboxSnippet
      },
      {
        title: 'Slots',
        snippet: SlotsSnippet
      },
      {
        title: 'Edit Dialog',
        snippet: EditDialogSnippet
      },
      {
        title: 'Crud',
        snippet: CrudSnippet
      }
    ]
  })
}
</script>
