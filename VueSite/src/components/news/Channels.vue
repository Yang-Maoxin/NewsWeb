<template>
  <div class="news-type" v-if="channels.length > 0">
    <div
      class="item"
      v-for="item in showChannels"
      :key="item.channelId"
      :class="{
        active: item.channelId === chooseId,
      }"
      @click="switchTo(item.channelId)"
    >
      <span class="name">{{ item.name }}</span>
    </div>
    <!-- //prevent 阻止事件默认值 -->
    <a href @click.prevent="isCollapse = !isCollapse">{{
      isCollapse ? "展开" : "收起"
    }}</a>
  </div>
</template>
<script>
// import {} from "@/Services/newsService"
import { GetNewsChannels } from "../../Services/newsService";
export default {
  data() {
    return {
      channels: [
        {
          channelId: -1,
          name: "全部",
        },
      ],
      isCollapse: true, //当前是否为折叠状态
      chooseId: -1, //当前选中的频道Id
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
    GetNewsChannels().then((resp) => {
      this.channels = this.channels.concat(resp.data.data);
      this.chooseId = this.channels[0].channelId;
    });
  },
  methods: {
    //切换chooseId
    switchTo(id) {
      this.chooseId = id;
      //我知道我的频道被切换了，但我不知道要干嘛？
      //触发一个事件，由父组件决定
      this.$emit("IdChange", this.chooseId,1,10);
    },
  },
  mounted() {
    this.$emit("IdChange", this.chooseId);
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
