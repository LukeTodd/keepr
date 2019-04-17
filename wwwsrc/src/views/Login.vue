<template>
    <div class="row">
        <div class="col-12">
            <div class="row">
                <login-nav></login-nav>
            </div>

            <!-- <div class="login">
                <form v-if="loginForm" @submit.prevent="loginUser">
                    <input type="email" v-model="creds.email" placeholder="email">
                    <input type="password" v-model="creds.password" placeholder="password">
                    <button type="submit">Login</button>
                </form>
                <form v-else @submit.prevent="register">
                    <input type="text" v-model="newUser.username" placeholder="name">
                    <input type="email" v-model="newUser.email" placeholder="email">
                    <input type="password" v-model="newUser.password" placeholder="password">
                    <button type="submit">Create Account</button>
                </form>
                <div @click="loginForm = !loginForm">
                    <p v-if="loginForm">No account Click to Register</p>
                    <p v-else>Already have an account click to Login</p>
                </div> -->
            <public-keeps v-for="keep in keeps" :keepData="keep"></public-keeps>
        </div>
    </div>
    </div>
</template>

<script>
    import LoginNav from '@/components/LoginNav.vue'
    import PublicKeeps from '@/components/PublicKeeps.vue'
    export default {
        name: "login",
        mounted() {
            //checks for valid session
            // this.$store.dispatch("authenticate");
            this.$store.dispatch("getAllKeeps")
        },
        // data() {
        //     return {
        //         loginForm: true,
        //         creds: {
        //             email: "",
        //             password: ""
        //         },
        //         newUser: {
        //             email: "",
        //             password: "",
        //             username: ""
        //         }
        //     };
        // },
        computed: {
            keeps() {
                return this.$store.state.keeps
            }
        },
        methods: {
            // register() {
            //     this.$store.dispatch("register", this.newUser);
            // },
            // loginUser() {
            //     this.$store.dispatch("login", this.creds);
            // }
        },
        components: {
            PublicKeeps,
            LoginNav
        }
    };
</script>