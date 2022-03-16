<template>
  <div class="email-editor">
    <email-input label="To:" :addresses="toAddresses">
      <v-btn icon @click="showCC = !showCC">
        Cc
      </v-btn>
      <v-btn icon class="mr-2" @click="showBCC = !showBCC">
        Bcc
      </v-btn>
    </email-input>
    <v-divider></v-divider>

    <div v-if="showCC">
      <email-input label="Cc:">
        <v-btn icon class="mr-2" @click="showCC = false">
          <v-icon small>mdi-close</v-icon>
        </v-btn>
      </email-input>
      <v-divider></v-divider>
    </div>

    <div v-if="showBCC">
      <email-input label="Bcc:">
        <v-btn icon class="mr-2" @click="showBCC = false">
          <v-icon small>mdi-close</v-icon>
        </v-btn>
      </email-input>
      <v-divider></v-divider>
    </div>

    <v-text-field :label="$t('email.subject')" solo flat hide-details></v-text-field>
    <v-divider></v-divider>

    <editor-menu-bar v-slot="{ commands, isActive }" :editor="editor">
      <div class="pa-1">
        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.bold() }"
          @click="commands.bold"
        >
          <v-icon>mdi-format-bold</v-icon>
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.italic() }"
          @click="commands.italic"
        >
          <v-icon>mdi-format-italic</v-icon>
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.strike() }"
          @click="commands.strike"
        >
          <v-icon>mdi-format-strikethrough</v-icon>
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.underline() }"
          @click="commands.underline"
        >
          <v-icon>mdi-format-underline</v-icon>
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.paragraph() }"
          @click="commands.paragraph"
        >
          <v-icon>mdi-format-paragraph</v-icon>
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.heading({ level: 1 }) }"
          @click="commands.heading({ level: 1 })"
        >
          H1
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.heading({ level: 2 }) }"
          @click="commands.heading({ level: 2 })"
        >
          H2
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.heading({ level: 3 }) }"
          @click="commands.heading({ level: 3 })"
        >
          H3
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.bullet_list() }"
          @click="commands.bullet_list"
        >
          <v-icon>mdi-format-list-bulleted</v-icon>
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.ordered_list() }"
          @click="commands.ordered_list"
        >
          <v-icon>mdi-format-list-numbered</v-icon>
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.blockquote() }"
          @click="commands.blockquote"
        >
          <v-icon>mdi-format-quote-close</v-icon>
        </v-btn>

        <v-btn
          icon
          tile
          :class="{ 'is-active': isActive.code_block() }"
          @click="commands.code_block"
        >
          <v-icon>mdi-code-tags</v-icon>
        </v-btn>

        <v-btn icon tile @click="commands.horizontal_rule">
          <v-icon>mdi-minus</v-icon>
        </v-btn>

        <v-btn icon tile @click="commands.undo">
          <v-icon>mdi-undo</v-icon>
        </v-btn>

        <v-btn icon tile @click="commands.redo">
          <v-icon>mdi-redo</v-icon>
        </v-btn>

      </div>
    </editor-menu-bar>

    <v-divider></v-divider>

    <editor-content class="editor__content pa-3 py-4" :editor="editor" />

    <v-divider></v-divider>

    <div class="d-flex align-center pa-2">
      <v-btn color="primary">
        {{ $t('email.send') }}
      </v-btn>
      <v-file-input hide-input class="pa-0 mx-1"></v-file-input>
    </div>
  </div>
</template>

<script>
import EmailInput from './EmailInput'
import { Editor, EditorContent, EditorMenuBar } from 'tiptap'
import {
  Blockquote,
  CodeBlock,
  HardBreak,
  Heading,
  HorizontalRule,
  OrderedList,
  BulletList,
  ListItem,
  TodoItem,
  TodoList,
  Bold,
  Code,
  Italic,
  Link,
  Strike,
  Underline,
  History
} from 'tiptap-extensions'

/*
|---------------------------------------------------------------------
| Email Editor Component
|---------------------------------------------------------------------
|
| Form to send and edit email content built on top of tip tap plugin
|
*/
export default {
  components: {
    EditorContent,
    EditorMenuBar,
    EmailInput
  },
  data() {
    return {
      toAddresses: [{
        text: 'Ruben Breitenberg',
        email: 'ruben@notarealemailaddress.com',
        avatar: '/images/avatars/avatar2.svg'
      }, {
        text: 'Blaze Carter',
        email: 'blaze@notarealemailaddress.com',
        avatar: '/images/avatars/avatar3.svg'
      }],
      showCC: false,
      showBCC: false,
      toggleFormat: [],
      editor: new Editor({
        extensions: [
          new Blockquote(),
          new BulletList(),
          new CodeBlock(),
          new HardBreak(),
          new Heading({ levels: [1, 2, 3] }),
          new HorizontalRule(),
          new ListItem(),
          new OrderedList(),
          new TodoItem(),
          new TodoList(),
          new Link(),
          new Bold(),
          new Code(),
          new Italic(),
          new Strike(),
          new Underline(),
          new History()
        ],
        content: `
          <h3>
            Hi there,
          </h3>
          <p>
            <br />
            I'll take my boat.
          </p>
          <blockquote>
            Best regards 👏
            <br />
            – Tom Cruise
          </blockquote>
        `
      })
    }
  },
  beforeDestroy() {
    this.editor.destroy()
  }
}
</script>

<style lang="scss">
.email-editor {
  position: relative;

  .v-btn {
    &.is-active {
      background-color: #f1f1f1;
    }
  }

  .editor__content {
    overflow-wrap: break-word;
    word-wrap: break-word;
    word-break: break-word;

    * {
      caret-color: currentColor;
    }

    .ProseMirror {
      &:focus {
        outline: none;
      }
    }

    ul,
    ol {
      padding-left: 1rem;
    }

    li > p,
    li > ol,
    li > ul {
      margin: 0;
    }

    a {
      color: inherit;
    }

    blockquote {
      border-left: 3px solid rgba(0, 0, 0, 0.1);
      color: rgba(0, 0, 0, 0.8);
      padding-left: 0.8rem;
      font-style: italic;

      p {
        margin: 0;
      }
    }

    img {
      max-width: 100%;
      border-radius: 3px;
    }

    table {
      border-collapse: collapse;
      table-layout: fixed;
      width: 100%;
      margin: 0;
      overflow: hidden;

      td,
      th {
        min-width: 1em;
        border: 2px solid #fafafa;
        padding: 3px 5px;
        vertical-align: top;
        box-sizing: border-box;
        position: relative;
        > * {
          margin-bottom: 0;
        }
      }

      th {
        font-weight: bold;
        text-align: left;
      }

      .selectedCell:after {
        z-index: 2;
        position: absolute;
        content: "";
        left: 0;
        right: 0;
        top: 0;
        bottom: 0;
        background: rgba(200, 200, 255, 0.4);
        pointer-events: none;
      }

      .column-resize-handle {
        position: absolute;
        right: -2px;
        top: 0;
        bottom: 0;
        width: 4px;
        z-index: 20;
        background-color: #adf;
        pointer-events: none;
      }
    }

    .tableWrapper {
      margin: 1em 0;
      overflow-x: auto;
    }

    .resize-cursor {
      cursor: ew-resize;
      cursor: col-resize;
    }
  }
}
</style>
