import { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';

function App() {
  const [state, setstate] = useState([])
  useEffect(() => {
    axios.get("http://localhost:5170/api/blog/533736b9-5660-433b-b6f2-e579392d6a82").then((res: any)=>{
      setstate(res.data)
    })
  }, [])
  return (
    <div>
      {JSON.stringify(state)}
    </div>
  );
}

export default App;
