<script setup>
import { RouterLink, useRoute } from "vue-router";
import logo from '@/assets/img/logo.png';

const isActiveLink = (routePath) => routePath === useRoute().path;
</script>

<template>
  <nav class="bg-green-700 border-b border-green-500">
    <div class="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
      <div class="flex h-20 items-center justify-between">
        <div class="flex flex-1 items-center justify-center md:items-stretch md:justify-start">
          <!-- Logo -->
          <RouterLink class="flex flex-shrink-0 items-center mr-4" to="/">
            <img :src="logo" alt="Vue Jobs" class="h-10 w-auto" />
            <span class="hidden md:block text-white text-2xl font-bold ml-2">Vue Jobs</span>
          </RouterLink>
          <div class="md:ml-auto">
            <div class="flex space-x-2">
<!--              <RouterLink :class="[text-white, bg-green-900, hover:bg-gray-900, hover:text-white, rounded-md, px-3, py-2]"-->
              <RouterLink :class="[isActiveLink('/') ? 'bg-green-900' : 'hover:bg-gray-900 hover:text-white', 'text-white', 'px-3', 'py-2', 'rounded-md']"
                to="/">
                Home
              </RouterLink>
              <RouterLink :class="[isActiveLink('/jobs') ? 'bg-green-900' : 'hover:bg-gray-900 hover:text-white', 'text-white', 'px-3', 'py-2', 'rounded-md']" to="/jobs">
                Jobs
              </RouterLink>
              <RouterLink :class="[isActiveLink('/jobs/add') ? 'bg-green-900' : 'hover:bg-gray-900 hover:text-white', 'text-white', 'px-3', 'py-2', 'rounded-md']" to="/jobs/add">
                Add Job
              </RouterLink>
            </div>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>
