<script setup>
  import {ref, onMounted} from "vue";

  const name = ref('John Doe');
  const status = ref('active');
  const tasks = ref(['Task One', 'Task Two', 'Task Three']);
  const newTask = ref('');

  const toggleStatus = () => {
    if (status.value === 'active') {
      status.value = 'pending';
    } else if (status.value === 'pending') {
      status.value = 'inactive';
    } else {
      status.value = 'active';
    }
  };
  
  const addTask = () => {
    if(newTask.value.trim() !== '') {
      tasks.value.push(newTask.value);
      newTask.value = '';
    }
  };
  
  const deleteTask = (index) => {
    tasks.value.splice(index, 1);
  }
  
  onMounted(async () => {
    try {
      const response = await fetch('http://localhost:4000/tasks')
      const data = await response.json();
      tasks.value = data.map((t) => t.title);
    } catch (error) {
      console.log(`Error fetching tasks: ${error}`);
    }   
  });
</script>

<template>
  <h1>Vue Jobs</h1>
  <h2>{{ name }}</h2>
  <p v-if="status === 'active'">User is active</p>
  <p v-else-if="status === 'pending'">User is pending</p>
  <p v-else>User is inactive</p>
  
  <form @submit.prevent="addTask">
    <label for="newTask">Add Task</label>
    <input id="newTask" v-model="newTask">
    <button type="submit">Submit</button>
  </form>
  
  <h3>Tasks:</h3>
  <ul>
    <li v-for="(task, index) in tasks" :key="task">
      <span>{{task}}</span>
      <button @click="deleteTask(index)">x</button>
    </li>
  </ul>
  <br/>
<!--  <button v-on:click="toggleStatus">Change Status</button>-->
  <button @click="toggleStatus">Change Status</button>
</template>