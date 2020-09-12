<template>
  <div id="app">
    <div style=" width:1080px;margin:0px auto;">
      <Home></Home>
      <!-- <Banner :banners="banners" :duration="2000"></Banner>
      <Channels @IdChange="handleChange" />
      <NewsList :news=""></NewsList> -->
      <!-- <Center><Loading/></Center> -->
    </div>
  </div>
</template>

<script>
import Home from "./views/Home"
//两种方式都是webpack支持  不是浏览器支持
export default {
  name: "App",
  components: {
   Home,
  },
  data() {
    return {
     
    };
  },
  methods: {
    handleChange(newId) {
      console.log("父组件输出 " + newId);
    },
  },
};
</script>

<style>

</style>
