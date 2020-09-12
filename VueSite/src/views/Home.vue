<template>
  <div>
    <Banner :banners="banners" :duration="2000"></Banner>
    <Channels @IdChange="handleChange"></Channels>
    <Loading v-show="isLoading"></Loading>
    <NewsList  v-show="!isLoading" :news="news"></NewsList>
  </div>
</template>

<script>
import Banner from "../components/Banner";
import Channels from "../components/news/Channels";
import NewsList from "../components/news/NewsList";
import Loading from "../components/Loading";
import baby1 from "../assets/banner/baby1.jpg";
import { GetNews } from "../Services/newsService";
export default {
  components: {
    Banner,
    Channels,
  },
  data() {
    return {
      banners: [
        { url: baby1, link: "https://www.baidu.com/" },
        {
          url: require("../assets/banner/baby2.jpg"),
          link: "https://www.baidu.com/",
        },
        {
          url: require("../assets/banner/baby3.jpg"),
          link: "https://www.baidu.com/",
        },
      ],
      news: [],
      isLoading:true
    };
  },
  methods: {
    handleChange(channelId) {
        this.isLoading=true
      console.log("频道Id" & channelId);
      GetNews(channelId, 1, 10).then((resp) => {
        this.news = resp.contentlist;
        this.isLoading=false
      });
    },
  },
};
</script>

<style>
</style>