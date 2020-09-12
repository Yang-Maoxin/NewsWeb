<template>
  <div class="news-type" v-if="channels.length>0">
    <div
      class="item"
      v-for="item in showChannels"
      :key="item.channelId"
      :class="{
        active : item.channelId===chooseId,
    }"
      @click="switchTo(item.channelId)"
    >
      <span class="name">{{item.name}}</span>1
    </div>
    <!-- //prevent 阻止事件默认值 -->
    <a href @click.prevent="isCollapse=!isCollapse">{{isCollapse?"展开":"收起"}}</a>
  </div>
</template>
<script>
// import {} from "@/Services/newsService"
import { GetNewsChannels } from "../../Services/newsService";
export default {
  data() {
    return {
      channels: [
        //频道列表
        {
          channelId: "5572a108b3cdc86cf39001cd", //频道id
          name: "国内焦点", //频道名称
        },
        {
          channelId: "5572a108b3cdc86cf39001ce",
          name: "国际焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001cf",
          name: "军事焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001d0",
          name: "财经焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001d1",
          name: "互联网焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001d2",
          name: "房产焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001d3",
          name: "汽车焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001d4",
          name: "体育焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001d5",
          name: "娱乐焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001d6",
          name: "游戏焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001d7",
          name: "教育焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001d8",
          name: "女人焦点",
        },
        {
          channelId: "5572a108b3cdc86cf39001d9",
          name: "科技焦点",
        },
        {
          channelId: "5572a109b3cdc86cf39001da",
          name: "社会焦点",
        },
        {
          channelId: "5572a109b3cdc86cf39001db",
          name: "国内最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001dc",
          name: "台湾最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001dd",
          name: "港澳最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001de",
          name: "国际最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001df",
          name: "军事最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001e0",
          name: "财经最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001e1",
          name: "理财最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001e2",
          name: "宏观经济最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001e3",
          name: "互联网最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001e4",
          name: "房产最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001e5",
          name: "汽车最新",
        },
        {
          channelId: "5572a109b3cdc86cf39001e6",
          name: "体育最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001e7",
          name: "国际足球最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001e8",
          name: "国内足球最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001e9",
          name: "CBA最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001ea",
          name: "综合体育最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001eb",
          name: "娱乐最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001ec",
          name: "电影最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001ed",
          name: "电视最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001ee",
          name: "游戏最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001ef",
          name: "教育最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001f0",
          name: "女人最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001f1",
          name: "美容护肤最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001f2",
          name: "情感两性最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001f3",
          name: "健康养生最新",
        },
        {
          channelId: "5572a10ab3cdc86cf39001f4",
          name: "科技最新",
        },
        {
          channelId: "5572a10bb3cdc86cf39001f5",
          name: "数码最新",
        },
        {
          channelId: "5572a10bb3cdc86cf39001f6",
          name: "电脑最新",
        },
        {
          channelId: "5572a10bb3cdc86cf39001f7",
          name: "科普最新",
        },
        {
          channelId: "5572a10bb3cdc86cf39001f8",
          name: "社会最新",
        },
      ],
      isCollapse: true, //当前是否为折叠状态
      chooseId: null, //当前选中的频道Id
    };
  },
  computed: {
    //需要显示的频道
    showChannels() {
      if (this.isCollapse) {
        //折叠状态
        return this.channels.slice(0, 8); //折叠状态只取8个
      } else {
        return this.channels;
      }
    },
  },
  //第一种写法
  created() {
    // GetNewsChannels().then(resp=>{
    // this.channels=resp
    this.chooseId = this.channels[0].channelId;
    // })
  },
  methods: {
    //切换chooseId
    switchTo(id) {
      this.chooseId = id;
      //我知道我的频道被切换了，但我不知道要干嘛？
      //触发一个事件，由父组件决定
      this.$emit("IdChange",this.chooseId);
    },
  },
  //   //第二种写法
  //   async created(){
  // // var resp=await GetNewsChannels();
  // // this.channels=resp
  //   }
};
</script>

<style scoped>
.news-type {
  margin: 30px 0;
  border-bottom: 1px solid #ccc;
  display: flex;
  flex-wrap: wrap;
  font-size: 14px;
  padding-bottom: 15px;
}
.item {
  padding: 10px 20px;
  border-radius: 5px;
  border: 1px solid #ccc;
  margin-right: 15px;
  margin: 7px 15px 7px 0;
  cursor: pointer;
  position: relative;
}
.item.hover {
  background: #ccc;
}
.item.active {
  background: #000;
  color: #fff;
}
.news-type a {
  align-self: flex-end;
  margin-bottom: 20px;
  color: #409eff;
}
</style>>
