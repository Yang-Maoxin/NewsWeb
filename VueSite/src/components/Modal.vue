<template>
<!-- 遮罩层 -->
  <div class="modal">
      <slot></slot>
  </div>
</template>

<style scoped>
.modal{
    widows: 100%;
    height: 100%;
    position: fixed;
    z-index: 200;
    background: rgba(0,0,0,0.5);
    left:0;
    top: 0;
}

</style>