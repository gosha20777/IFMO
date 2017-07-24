(defn operator [appfn args] 
  (fn [vars] 
    (appfn (map (fn [a] (a vars)) args))))

(defn add [& args]
  (operator (fn [a] (reduce + a)) args))

(defn subtract [& args]
  (operator (fn [a] (reduce - a)) args))

(defn multiply [& args]
  (operator (fn [a] (reduce * a)) args))

(defn divide [& args]
  (operator (fn [a] (try
                      (reduce / a)
                      (catch Exception e (/ 1.0 0.0)))) args))

(defn negate [arg]
  (fn [vars] (- (arg vars))))

(defn sin [arg]
  (fn [vars] (Math/sin (arg vars))))

(defn cos [arg]
  (fn [vars] (Math/cos (arg vars))))

(defn constant [v]
  (fn [vars] (double v)))

(defn variable [nam]
  (fn [vars] (double (get vars nam))))

(defn parseFunction [expression]
  (let [bin-op {'+ add '- subtract '* multiply '/ divide}
        un-op {'sin sin 'cos cos 'negate negate}]
    (cond
      (string? expression) (parseFunction (read-string expression))
      (seq? expression)
        (let [exp (first expression)]
            (cond
              (contains? bin-op exp) (apply (get bin-op exp) (map parseFunction (rest expression)))
              (contains? un-op exp) ((get un-op exp) (parseFunction (second expression)))))
      (or (integer? expression) (float? expression)) (constant expression)
      (symbol? expression) (variable (str expression)))))
