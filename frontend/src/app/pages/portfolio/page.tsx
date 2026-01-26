export default function Portfolio() {
  return (
    <div className="min-h-screen flex items-center justify-center bg-slate-900 font-sans">
      <div className="bg-slate-800 w-105 rounded-2xl shadow-xl overflow-hidden">

        <div className="bg-linear-to-r from-indigo-600 to-purple-600 p-4">
          <h1 className="text-white text-lg font-semibold">
            Username's Portfolio
          </h1>
        </div>

        <div className="p-6 space-y-4">
          <div className="bg-slate-700 rounded-xl p-4 flex items-center justify-between">
            <div>
              <p className="text-slate-300 text-sm">Cash Balance</p>
              <p className="text-white text-xl font-bold">$100,000.00</p>
            </div>
            <div className="bg-green-500/20 text-green-400 px-3 py-1 rounded-full text-sm font-semibold">
              Available
            </div>
          </div>

          <div className="bg-slate-700 rounded-xl p-4 text-slate-400 text-sm text-center">
            No holdings yet
          </div>
        </div>

      </div>
    </div>
  );
}