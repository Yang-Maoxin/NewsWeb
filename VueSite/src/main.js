import Vue from "vue";
import App from "./App.vue";
import{GetUsers} from  "./Services/newsService"

// import{GetNewsChannels} from  "./Services/newsService"
// //第一种调用方式
// GetNewsChannels().then(resp=>{
//   console.log(resp)
// })
// //第二种
// async function test(){
//   var resp=await GetNewsChannels();
//   console.log(resp)
// }
// test();

new Vue({
  render: (h) => h(App),
}).$mount("#app");
