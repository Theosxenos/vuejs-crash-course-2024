import {createRouter, createWebHistory} from "vue-router";
import HomeView from "@/views/HomeView.vue";
import JobsView from "@/views/JobsView.vue";
import PageNotFoundView from "@/views/PageNotFoundView.vue";
import JobView from "@/views/JobView.vue";
import AddJobView from "@/views/AddJobView.vue";
import EditView from "@/views/EditView.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
          path: '/:catchAll(.*)',
          name: 'not-found',
          component: PageNotFoundView,  
        },
        {
            path: '/',
            name: 'home',
            component: HomeView,
        },
        {
          path: '/jobs',
          name: 'jobs',
          component: JobsView  
        },
        {
            path: '/jobs/:id',
            name: 'job',
            component: JobView,
        },        
        {
            path: '/jobs/edit/:id',
            name: 'edit-job',
            component: EditView,
        },
        {
          path: '/jobs/add',
          name: 'add-jobs',
          component: AddJobView  
        },
    ],
});

export default router;