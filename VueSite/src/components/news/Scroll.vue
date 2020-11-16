<template>
	<div class="yl-scroll">
		<slot></slot>
	</div>
</template>

<script>
/* eslint-disable */
export default {
	data() {
		return {};
	},
	mounted() {
		let self = this;
		this.$nextTick(() => {
			setTimeout(() => {
				self.initParams();
			}, 300);
		});
	},
	methods: {
		initParams() {
			let target = this.$attrs["target"];
			if (target) {
				this.scrollEl = document.querySelector(target);
				let contentH = this.scrollEl.clientHeight;
				var scrollHight = this.scrollEl.scrollHeight;
				// console.log(contentH, scrollHight);
				let self = this,
					flagNum = 0; // 防止程序陷入死循环
				var flag = setInterval(() => {
					scrollHight = self.scrollEl.scrollHeight;
					if (contentH >= scrollHight && flagNum <= 5) {
						self.$emit("scroll", {
							scrollTop: 0,
							isBottom: true
						});
						flagNum++;
					} else {
						flagNum = 0;
						clearInterval(flag);
					}
				}, 1);

				// console.log(contentH, scrollHight);

				this.scrollEl.onscroll = function() {
					contentH = self.scrollEl.clientHeight;
					scrollHight = self.scrollEl.scrollHeight;
					let scrollTop = self.scrollEl.scrollTop;
					// console.log(Math.ceil(contentH + scrollTop), scrollHight);
					if (Math.ceil(contentH + scrollTop) >= scrollHight) {
						self.$emit("scroll", {
							scrollTop: scrollTop,
							isBottom: true
						});
					} else {
						self.$emit("scroll", {
							scrollTop: scrollTop,
							isBottom: false
						});
					}
				};
			} else {
				console.warn("not find scroll target");
			}
		}
	}
};
</script>
<style  scoped>
.yl-scroll {
	height: 100%;
}
</style>